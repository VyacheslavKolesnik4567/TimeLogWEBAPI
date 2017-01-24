app.factory("UserService", function ($http) {
    return {
        GetUsersAsync: function () {
            return $http({ method: "GET", url: "api/user"});
        }
    };
});