var RatingService = function () {
    var createRating = function(planId, value, done, fail) {
        $.post("/api/ratings", { planId: planId, value: value })
            .done(done)
            .fail(fail);
    };

    var deleteRating = function(planId, done, fail) {
        $.ajax({
                url: "/api/ratings/" + planId,
                method: "DELETE"
            })
            .done(done)
            .fail(fail);
    };

    var getRating = function(planId) {
        var result = null;
        $.ajax({
            url: "/api/ratings/" + planId,
            type: 'get',
            dataType: 'html',
            async: false,
            success: function (data) {
                result = data;
            }
        });
        return result;
    };

    var getRatingCount = function(planId) {
        var result = null;
        $.ajax({
            url: "/api/ratings/count/" + planId,
            type: 'get',
            dataType: 'html',
            async: false,
            success: function(data) {
                result = data;
            }
        });
        return result;
    };

    var getUserRatingCount = function (userId) {
        var result = null;
        $.ajax({
            url: "/api/ratings/user-count/" + userId,
            type: 'get',
            dataType: 'html',
            async: false,
            success: function(data) {
                result = data;
            }
        });
        return result;
    };

    return {
        createRating: createRating,
        deleteRating: deleteRating,
        getRating: getRating,
        getRatingCount: getRatingCount,
        getUserRatingCount: getUserRatingCount
    };
}();