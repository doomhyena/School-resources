$(document).ready(function () {
	$('.productSVG').click(function () {
		var prodID = $(this).attr('id').split('_')[1];
		AddToCart(prodID);
	});	
});

function AddToCart(prodID) {
	$.ajax({
		type: "GET",
		url: "http://localhost:49909/api/AddToCart/" + prodID,
		dataType: "json",
		contentType: "application/json; charset=utf-8",
		success: function (response) {
			$('#CartCounter').text(response);
		},
		failure: function () { alert("Error!"); },
		error: function () { alert("Error!"); }
	});
};