var RatingService = function () {
    var createRating = function (planId, value, done, fail) {
        $.post("/api/ratings", { planId: planId, value: value })
            .done(done)
            .fail(fail)
    }

    var deleteRating = function (planId, done, fail) {
        $.ajax({
            url: "/api/ratings/" + planId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail)
    }

    return {
        createRating: createRating,
        deleteRating: deleteRating
    }
}()