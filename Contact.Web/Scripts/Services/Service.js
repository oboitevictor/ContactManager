/// <reference path="../angular.js" />
/// <reference path="../Modules/Module.js" />

app.service('crudService', function ($http) {


    //Create new record
    this.post = function (ContactViewModel) {
        var request = $http({
            method: "post",
            url: "/api/Contact",
            data: ContactViewModel
        });
        return request;
    }
    //Get Single Records
    this.get = function (id) {
        return $http.get("/api/Contact/" + id);
    }

    //Get All Contact
    this.GetContacts = function () {
        return $http.get("/api/Contact");
    }


    //Update the Record
    this.put = function (id, ContactViewModel) {
        var request = $http({
            method: "put",
            url: "/api/Contact/" + id,
            data: ContactViewModel
        });
        return request;
    }
    //Delete the Record
    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/Contact/" + id
        });
        return request;
    }
});