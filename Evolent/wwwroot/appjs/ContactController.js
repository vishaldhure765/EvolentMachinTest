
EvolentApp.controller('contactController1', ['$http', '$scope', 'API', 'toaster', function ($http, $scope, API, toaster) {

    $scope.contactForm =
        {
            Id: 0,
            FirstName: null,
            LastName: null,
            Email: null,
            PhoneNumber: null,
            Status: 'Y'
        };

    function GetContactList() {

        // $("#divLoader").show();
        API.Get("/api/ContactDetails").then(function (response) {
            $("#divLoader").hide();
            if (response.status = 200) {
                $scope.ContactList = response.data;
            }
            else {
                alert("something went wrong");
            }

        });
    }

    GetContactList();

    $scope.Clear = function () {
        $scope.contactForm.Id = 0;
        $scope.contactForm.FirstName = null;
        $scope.contactForm.LastName = null;
        $scope.contactForm.Email = null;
        $scope.contactForm.Status = 'Y';
        $scope.contactForm.PhoneNumber = null;
    }

    $scope.AddContact = function () {
        $("#modal-contactinfo").modal();
    }

    $scope.edit = function (data) {
        $scope.contactForm.Id = data.id
        $scope.contactForm.FirstName = data.firstName;
        $scope.contactForm.LastName = data.lastName;
        $scope.contactForm.Email = data.email;
        if (data.status == true)
            $scope.contactForm.Status = 'Y';
        else
            $scope.contactForm.Status = 'N';

        $scope.contactForm.PhoneNumber = data.phoneNumber;
        $("#modal-contactinfo").modal();
    }

    $scope.delete = function (id) {
        API.Get("/api/ContactDetails/" + id).then(function (response) {
            $("#divLoader").hide();
            if (response.status = 200) {
                alert("Contact deleted successfully");
                GetContactList();
            }
            else {
                alert("something went wrong");
            }

        });
    }

    $scope.submit = function (isValid) {
        //alert(isValid);
        if (isValid) {
            if ($scope.contactForm.Status === "Y")
                $scope.contactForm.Status = true;
            else
                $scope.contactForm.Status = false;

            API.Post("/api/ContactDetails", $scope.contactForm).then(function (response) {
                $("#modal-contactinfo").modal('hide');
                if (response.status = 200) {
                    alert("Contact saved successfully");
                    toaster.pop('success', "success", "Contact saved sucessfully !");
                    GetContactList();
                    //$scope.contactForm.$setPristine();
                    $scope.Clear();
                }
                else
                    alert("Wrong");
            });
        }
    }
}]);
