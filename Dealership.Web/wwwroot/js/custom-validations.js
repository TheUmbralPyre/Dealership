const electricEngineNumber = 2;


$.validator.addMethod('electricenginecannothavedisplacement', function (value, element, params) {
    if (document.getElementById("type").value == electricEngineNumber && value != "") {
        return false;
    }
    else {
        return true;
    }
});

$.validator.unobtrusive.adapters.addBool("electricenginecannothavedisplacement");

$.validator.addMethod('requireddisplacementonnonelectricengine', function (value, element, params) {
    if (document.getElementById("type").value != electricEngineNumber && value == "") {
        return false;
    }
    else {
        return true;
    }
});

$.validator.unobtrusive.adapters.addBool("requireddisplacementonnonelectricengine");