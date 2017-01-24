app.controller("UserController", function ($scope, UserService, $uibModal) {
    //Users loading function
    $scope.loadUsers = function () {
        //Request to the server for getting users
        UserService.GetUsersAsync().then(function (response) {
            $scope.users = response.data;
        });
    }

    $scope.loadUsers();

    $scope.timeLogModalOpen = function(userId)
    {
        var modalInstance = $uibModal.open({
            templateUrl: "WebUI/Scripts/TimeLogs/LogTimeModal.html",
            controller: 'TimeLogController',
            size: 'lg',
            resolve: {
                timeLog: function () {
                    return { UserId: userId}
                },
                users: $scope.users
            }
        });

        modalInstance.result.then(function (timeLog) {
            //Http request to the server
            hobbitsService.AddHobbitAsync(hobbit)
                //Succes func
                .success(function (data, status, headers, config) {
                    if (data.Code == 201) {
                        $uibModal.open({
                            templateUrl: "Scripts/MyScripts/Angular/Templates/message.html",
                            animation: true,
                            controller: function ($scope) {
                                $scope.message = { Status: "Success", Description: "Hobbit created succesfully." };
                            },
                            size: 'sm',
                        });
                        hobbitsLoad();
                    }
                    else
                        $uibModal.open({
                            templateUrl: "Scripts/MyScripts/Angular/Templates/message.html",
                            animation: true,
                            controller: function ($scope) {
                                $scope.message = { Status: "Failed", Description: "Hobbit didn't created. " + data.Description };
                            },
                            size: 'sm',
                        });
                })
                //Error func
                .error(function (data, status, headers, config) {
                    var message = status == 500 ? "File is too big. Max file size 4Mb." : "Problems with the server connection.";
                    $uibModal.open({
                        templateUrl: "Scripts/MyScripts/Angular/Templates/message.html",
                        animation: true,
                        controller: function ($scope) {
                            $scope.message = { Status: "Failed", Description: "Hobbit didn't created. " + message };
                        },
                        size: 'sm',
                    });
                });
        });
    };
});