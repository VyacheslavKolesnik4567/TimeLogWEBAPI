app.factory("TimeLogService", function ($http) {
    return {
        AddTimeLogAsync: function (timeLog) {
            return $http({ method: "POST", url: "api/timeLog", params: timeLog });
        }
    };
});