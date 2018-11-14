var IndexController = function (favouriteService, ratingService) {
    var button;
    var operation;
    var planId;

    var init = function () {
        $(".plan-block").each(function (index) {
            $(this).delay(200 * index).fadeIn();
        });
        $('.js-star-rating').rating({theme: 'krajee-fa'});
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
        ratingService.createRating(planId, value, changeRatingDone, fail);
    };

    //Remove rating (DELETE)
    var clearRating = function (event, value, caption) {
        var input = $(event.target);
        planId = input.attr("data-plan-id");
        operation = "Removing rating";
        ratingService.deleteRating(planId, changeRatingDone, fail);
    };

    var faveDone = function () {
        var text = (button.text() === "Favourite") ? "Favourite?" : "Favourite";
        button.hide();
        button.toggleClass("btn-info").toggleClass("btn-inverse").text(text).fadeIn(1000);
        console.log(operation + " for plan ID " + planId + " was successful!");
    };

    var changeRatingDone = function () {
        //update rating value
        var rating = ratingService.getRating(planId);
        $("#rating-value-" + planId).hide();
        $("#rating-value-" + planId).text(rating + "/5").fadeIn(1000);
        //update rating count
        var ratingCount = ratingService.getRatingCount(planId);
        var newText = ratingCount !== 1 ? ratingCount + " ratings" : ratingCount + " rating";
        $("#rating-count-" + planId).hide();
        $("#rating-count-" + planId).text(newText).fadeIn(1000);
    };

    var done = function () {
        console.log(operation + " for plan ID " + planId + " was successful!");
    };

    var fail = function () {
        console.log(operation + " for planId " + planId + " failed!");
    };

    return {
        init: init
    };
}(FavouriteService, RatingService);