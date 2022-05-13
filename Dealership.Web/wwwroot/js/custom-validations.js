const electricEngineNumber = 2;

//#region Electric Engine Cannot Have Displacement

$.validator.addMethod('electricenginecannothavedisplacement', function (value, element, params) {
    if (document.getElementById("type").value == electricEngineNumber && value != "") {
        return false;
    }
    else {
        return true;
    }
});

$.validator.unobtrusive.adapters.addBool("electricenginecannothavedisplacement");

//#endregion 

//#region Non Electric Engine Must Have Displacement

$.validator.addMethod('requireddisplacementonnonelectricengine', function (value, element, params) {
    if (document.getElementById("type").value != electricEngineNumber && value == "") {
        return false;
    }
    else {
        return true;
    }
});

$.validator.unobtrusive.adapters.addBool("requireddisplacementonnonelectricengine");

//#endregion 