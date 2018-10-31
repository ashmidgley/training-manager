var FavouriteService = function () {
    var createFavourite = function (planId, done, fail) {
        $.post("/api/favourites", { planId: planId })
            .done(done)
            .fail(fail);
    }

    var deleteFavourite = function (planId, done, fail) {
        $.ajax({
            url: "/api/favourites/" + planId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    }

    return {
        createFavourite: createFavourite,
        deleteFavourite: deleteFavourite
    }
}()