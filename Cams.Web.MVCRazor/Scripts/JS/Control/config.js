

// TAb
$(function() {
	$("ul.tabs").tabs("div.panes > div.panes-data");
});


var sipPos = 0;
$(document).ready(function() {
	$("#quick-panel-tab").click(function(e) {
		e.preventDefault();
		$("#quick-panel").animate({ bottom: sipPos }, 800, 'linear', function() {
			if(sipPos == -115) { sipPos = 0; }
			else { sipPos = -115; }
		});
	});
});


$(document).ready(function() {
	$(".dropdown img.flag").addClass("flagvisibility");

	$(".dropdown dt a").click(function() {
		$(".dropdown dd ul").toggle();
	});
				
				
	function getSelectedValue(id) {
		return $("#" + id).find("dt a span.value").html();
	}

	$(document).bind('click', function(e) {
		var $clicked = $(e.target);
		if (! $clicked.parents().hasClass("dropdown"))
			$(".dropdown dd ul").hide();
	});


	$("#flagSwitcher").click(function() {
		$(".dropdown img.flag").toggleClass("flagvisibility");
	});
});



ddsmoothmenu.init({
	mainmenuid: "smoothmenu1", //menu DIV id
	orientation: 'h', //Horizontal or vertical menu: Set to "h" or "v"
	classname: 'ddsmoothmenu', //class added to menu's outer DIV
	//customtheme: ["#1c5a80", "#18374a"],
	contentsource: "markup" //"markup" or ["container_id", "path_to_menu_file"]
});
