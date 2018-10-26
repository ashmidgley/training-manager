var RatingsController = function (ratingService) {
    var operation;
    var planId;

    var init = function (container) {
        $('.js-remove-rating').on('click', clearRating);
    };

    //Remove rating (DELETE)
    var clearRating = function (event, value, caption) {
        var input = $(event.target);
        planId = input.attr("data-plan-id");
        operation = "Removing rating";

        bootbox.dialog({
            message: "Are you sure you want to remove this rating?",
            title: "Confirm",
            buttons: {
                no: {
                    label: "No",
                    className: "btn-default",
                    callback: function () {
                        console.log("Cancelled removal of rating for plan " + planId);
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: "Yes",
                    className: "btn-danger",
                    callback: function () {
                        ratingService.deleteRating(planId, done, fail);
                    }
                }
            }
        });
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

}(RatingService)