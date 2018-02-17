
var FavouritesController = function (favouriteService) {
    var planId;
    var link;

    var init = function (container) {
        $(container).on("click", ".js-remove-favourite", removeFavourite);
    };

    var removeFavourite = function (e) {
        link = $(e.target);
        planId = link.attr("data-plan-id");

        bootbox.dialog({
            message: "Are you sure you want to remove this plan from favourites?",
            title: "Confirm",
            buttons: {
                no: {
                    label: "No",
                    className: "btn-default",
                    callback: function () {
                        console.log("Cancelled removal of favourite plan " + planId);
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: "Yes",
                    className: "btn-danger",
                    callback: function () {
                        favouriteService.deleteFavourite(planId, done, fail);
                    }
                }
            }
        })
    };

    var done = function () {
        link.parents("li").fadeOut(function () {
            $(this).remove();
        });
        console.log("Removing plan " + planId + " was successful");
    }

    var fail = function () {
        alert("Removing plan " + planId + " failed!");
    }

    return {
        init: init
    };
}(FavouriteService)