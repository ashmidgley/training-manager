var IndexController = function (favouriteService, ratingService) {
    var button;
    var operation;
    var planId;

    var init = function (container) {
        $('.js-toggle-favourite').click(toggleFavourite);
        $('.js-star-rating').on('rating:change', createRating);
        $('.js-star-rating').on('rating:clear', clearRating);
    };

    //A plan favourite is toggled by user
    var toggleFavourite = function (e) {
        button = $(e.target);
        planId = button.attr("data-plan-id");
        if (button.hasClass('btn-inverse')) {
            operation = "Posting Favourite";
            favouriteService.createFavourite(planId, faveDone, fail);
        } else {
            operation = "Deleting favourite";
            favouriteService.deleteFavourite(planId, faveDone, fail);
        }
    };

    //Create new rating (POST)
    var createRating = function (event, value, caption) {
        var input = $(event.target);
        planId = input.attr("data-plan-id");
        operation = "Posting rating";
        ratingService.createRating(planId, value, done, fail);
    };

    //Remove rating (DELETE)
    var clearRating = function (event, value, caption) {
        var input = $(event.target);
        planId = input.attr("data-plan-id");
        operation = "Removing rating";
        ratingService.deleteRating(planId, done, fail);
    };

    var faveDone = function () {
        var text = (button.text === "Favourite") ? "Favourite?" : "Favourite";
        button.toggleClass("btn-info").toggleClass("btn-inverse").text(text);
        console.log(operation + " for plan ID " + planId + " was successful!");
    };

    var done = function () {
        console.log(operation + " for plan ID " + planId + " was successful!");
    };

    var fail = function () {
        alert(operation + " for planId " + planId + " failed!");
    };

    return {
        init: init
    };
}(FavouriteService, RatingService);