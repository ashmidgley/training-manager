
var MineController = function (planService) {
    var link;
    var planId;

    var init = function () {
        $(".plan-block").each(function (index) {
            $(this).delay(200 * index).fadeIn();
        });
        $(".js-remove-plan").click(removePlan);
    };

    var removePlan = function (e) {
        link = $(e.target);
        planId = link.attr("data-plan-id");

        bootbox.dialog({
            message: "Are you sure you want to remove this plan?",
            title: "Confirm",
            buttons: {
                no: {
                    label: "No",
                    className: "btn-default",
                    callback: function () {
                        console.log("Cancelled removal of plan " + planId);
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: "Yes",
                    className: "btn-danger",
                    callback: function () {
                        planService.deletePlan(planId, done, fail);
                    }
                }
            }
        });
    }

    var done = function () {
        $("#mine-"+planId).fadeOut(500, function () {
            $(this).remove();
        });
        console.log("Removing plan " + planId + " was successful");
    }

    var fail = function () {
        console.log("Removing plan " + planId + " failed!");
    }

    return {
        init: init
    };
}(PlanService)