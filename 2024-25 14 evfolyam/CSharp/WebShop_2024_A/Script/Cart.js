$(document).ready(function () {
	$('.addBtn').click(function () {
		var prodID = $(this).attr('id').split('_')[1];
		AddToCart(prodID);
	});

	$('.delBtn').click(function () {
		var prodID = $(this).attr('id').split('_')[1];
		DeleteFromCart(prodID);
	});
	$('.removeBtn').click(function () {
		var prodID = $(this).attr('id').split('_')[1];
		RemoveFromCart(prodID);
	});
});

function AddToCart(prodID) {
	$.ajax({
		type: "GET",
		url: "http://localhost:49909/api/AddProduct/" + prodID,
		dataType: "json",
		contentType: "application/json; charset=utf-8",
		success: function (response) {
			$('#qty_' + prodID).val(response.Cart[prodID]);
			$('#sum_' + prodID).html("$" + (response.Cart[prodID] * response.Products[prodID].UnitPrice).toFixed(2));
			Update(response);
		},
		failure: function () { alert("Error!"); },
		error: function () { alert("Error!"); }
	});
};
function RemoveFromCart(prodID) {
	$.ajax({
		type: "GET",
		url: "http://localhost:49909/api/RemoveProduct/" + prodID,
		dataType: "json",
		contentType: "application/json; charset=utf-8",
		success: function (response) {
			if (response.Cart[prodID] !== undefined) {
				$('#qty_' + prodID).val(response.Cart[prodID]);
				$('#sum_' + prodID).html("$" + (response.Cart[prodID] * response.Products[prodID].UnitPrice).toFixed(2));
			} else {
				$('#tableRow_' + prodID).remove();
			}
			Update(response);
		},
		failure: function () { alert("Error!"); },
		error: function () { alert("Error!"); }
	});
};
function DeleteFromCart(prodID) {
	$.ajax({
		type: "GET",
		url: "http://localhost:49909/api/DeleteProduct/" + prodID,
		dataType: "json",
		contentType: "application/json; charset=utf-8",
		success: function (response) {
			$('#tableRow_' + prodID).remove();
			Update(response);
		},
		failure: function () { alert("Error!"); },
		error: function () { alert("Error!"); }
	});
};
function Update(response) {
	$('#sumPrice').text("$" + response.Sum);
	$('#CartCounter').text(response.TotalQ);
}