$(document).ready(function(){
	$(".icon").click(function(){
		$(".title").toggle();
		$(".container").css("position", "absolute");
	});
	$(".website").hide();
	$(".developer").hide();
	$(".website_a").click(function(){
		$("#dev_li").removeClass("active_li");
		$("#web_li").addClass("active_li");
		$(".website").fadeIn('medium');
		$(".developer").hide();
	});
	$(".developer_a").click(function(){
		$("#web_li").removeClass("active_li");
		$("#dev_li").addClass("active_li");
		$(".developer").fadeIn('medium');
		$(".website").hide();
	});
	$(".sub-nav").hide();
	$(".nav-btn").click(function(){
		var _this = $(".img");
      	var current = _this.attr("src");
      	var swap = _this.attr("data-swap");     
     	_this.attr('src', swap).attr("data-swap",current);

		if ( $( ".sub-nav:first" ).is( ":hidden" ) ) {
		    $( ".sub-nav" ).slideDown( "slow" );
		  } else {
		    $( ".sub-nav" ).slideUp();
		    $("#btn").addClass("bottom");
		  }
	});
});
