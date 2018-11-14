﻿var RatingsController = function (ratingService) {
    var operation;
    var planId;
    var link;
    var userId;

    var init = function (_userId) {
        userId = _userId;
        $('.js-remove-rating').click(clearRating);
    };

    //Remove rating (DELETE)
    var clearRating = function (event) {
        var input = $(event.target);
        link = $(event.target);
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
        link.parents("tr").find("td").fadeOut(500, function () {
            $(this).parent().remove();
            console.log(operation + " for plan ID " + planId + " was successful!");
            if ($("tr").length === 1) {
                location.reload();
                return;
            }
        });

        var ratingCount = ratingService.getUserRatingCount(userId);
        $("#my-ratings-count").hide();
        $("#my-ratings-count").text("You have rated " + ratingCount + " user plans.").fadeIn(1500);
    };

    var fail = function () {
        console(operation + " for planId " + planId + " failed!");
    };

    return {
        init: init
    };

}(RatingService)