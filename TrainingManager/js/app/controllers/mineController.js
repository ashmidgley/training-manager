
var MineController = function (planService) {
    var link;
    var planId;

    var init = function () {
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
        $(".plan-block").fadeOut(500, function () {
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
}(PlanService)