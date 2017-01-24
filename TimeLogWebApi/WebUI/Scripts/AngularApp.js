var app = angular.module("TimeLogApp", ['ngRoute', 'ui.bootstrap'])
    .config(function ($routeProvider) {
    $routeProvider.when('/users',
    {
        templateUrl: 'WebUI/Scripts/Users/UserList.html',
        controller: 'UserController'
    });

    $routeProvider.otherwise({ redirectTo: '/users' });
});;