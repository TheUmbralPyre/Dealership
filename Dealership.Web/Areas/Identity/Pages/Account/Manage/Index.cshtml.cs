using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dealership.Data.DataModels.IdentityModels;
using Dealership.Data.Models.IdentityModels;
using Dealership.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MapsterMapper;
using Mapster;

namespace Dealership.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IPictureService<ProfilePicture> _profilePictureService;
        private readonly IMapper _mapper;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IPictureService<ProfilePicture> profilePictureService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _profilePictureService = profilePictureService;
            _mapper = mapper;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [TempData]
        public string UsernameChangeLimitMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Username { get; set; }
            
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Profile Picture")]
            public byte[] ProfilePicture { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            var firstName = user.FirstName;
            var lastName = user.LastName;
            var profilePicture = user.ProfilePictureIndex;

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            // If the User's Change Limit is Not Zero...
            if (user.UsernameChangeLimit > 0)
            {
                // If there is a Difference between the Username in the Database and the Username in the Model...
                if (Input.Username != user.UserName)
                {
                    // Initialize a Variable And Assign to it a User WHo has the Same Username
                    var userNameExists = await _userManager.FindByNameAsync(Input.Username);
                    // If a User who has the Same Username Exists....
                    if (userNameExists != null)
                    {
                        // Assign a new Message to Status Message
                        StatusMessage = "User name already taken. Select a different username.";
                        // Redirect to the Page
                        return RedirectToPage();
                    }

                    // Attempt to set the Username and Assign the Result to a Variable
                    var setUserName = await _userManager.SetUserNameAsync(user, Input.Username);

                    // If the Username Wasn't Succesfully Changed...
                    if (!setUserName.Succeeded)
                    {
                        // Assign a new Message to Status Message
                        StatusMessage = "Unexpected error when trying to set user name.";
                        // Redirect to the Page
                        return RedirectToPage();
                    }
                    // If the Username Was Succesfully Changed...
                    else
                    {
                        // Reduce the Amount of Times that the Username can be Chnaged
                        user.UsernameChangeLimit -= 1;
                        // Assign a new Message to Username Chnage Limit Message
                        UsernameChangeLimitMessage = $"You can Change your Username {user.UsernameChangeLimit} more times.";
                        // Update the User
                        await _userManager.UpdateAsync(user);
                    }
                }
            }

            // Get the User's First Name
            var firstName = user.FirstName;
            // If there is a Difference between the First Name in the Database and the First Name in the Model...
            if (Input.FirstName != firstName)
            {
                // Set the User's First Name to the One in the Model
                user.FirstName = Input.FirstName;
                // Update the User
                await _userManager.UpdateAsync(user);
            }

            // Get the User's Last Name
            var lastName = user.LastName;
            // If there is a Difference between the Last Name in the Database and the Last Name in the Model...
            if (Input.LastName != lastName)
            {
                // Set the User's Last Name to the One in the Model
                user.LastName = Input.LastName;
                // Update the User
                await _userManager.UpdateAsync(user);
            }

            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    var picture = dataStream.ToArray();

                    var profilePicture = _profilePictureService.ConvertPicture(picture);

                    user = profilePicture.Adapt(user, _mapper.Config);
                }

                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
