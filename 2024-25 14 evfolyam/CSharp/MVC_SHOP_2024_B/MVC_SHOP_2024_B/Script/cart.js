$(document).ready(function () {
	$('.delProduct').click(function () {
		productID = $(this).attr('id').split('_')[1];
		DeleteProduct(productID);
	});
	$('.productDec').click(function () {
		productID = $(this).attr('id').split('_')[1];
		ProductDec(productID);
	});
	$('.productInc').click(function () {
		productID = $(this).attr('id').split('_')[1];
		ProductInc(productID);
	});
	$('.productDirect').keyup(function () {
		productID = $(this).attr('id').split('_')[1];
		ProductDirect(productID);
	});


	var slider = $("#slider");
	var thumb = $("#thumb");
	var slidesPerPage = 4; //globaly define number of elements per page
	var syncedSecondary = true;
	slider.owlCarousel({
		items: 1,
		slideSpeed: 2000,
		nav: false,
		autoplay: false,
		dots: false,
		loop: true,
		responsiveRefreshRate: 200
	}).on('changed.owl.carousel', syncPosition);
	thumb
		.on('initialized.owl.carousel', function () {
			thumb.find(".owl-item").eq(0).addClass("current");
		})
		.owlCarousel({
			items: slidesPerPage,
			dots: false,
			nav: true,
			item: 4,
			smartSpeed: 200,
			slideSpeed: 500,
			slideBy: slidesPerPage,
			navText: ['<svg width="18px" height="18px" viewBox="0 0 11 20"><path style="fill:none;stroke-width: 1px;stroke: #000;" d="M9.554,1.001l-8.607,8.607l8.607,8.606"/></svg>', '<svg width="25px" height="25px" viewBox="0 0 11 20" version="1.1"><path style="fill:none;stroke-width: 1px;stroke: #000;" d="M1.054,18.214l8.606,-8.606l-8.606,-8.607"/></svg>'],
			responsiveRefreshRate: 100
		}).on('changed.owl.carousel', syncPosition2);
	function syncPosition(el) {
		var count = el.item.count - 1;
		var current = Math.round(el.item.index - (el.item.count / 2) - .5);
		if (current < 0) {
			current = count;
		}
		if (current > count) {
			current = 0;
		}
		thumb
			.find(".owl-item")
			.removeClass("current")
			.eq(current)
			.addClass("current");
		var onscreen = thumb.find('.owl-item.active').length - 1;
		var start = thumb.find('.owl-item.active').first().index();
		var end = thumb.find('.owl-item.active').last().index();
		if (current > end) {
			thumb.data('owl.carousel').to(current, 100, true);
		}
		if (current < start) {
			thumb.data('owl.carousel').to(current - onscreen, 100, true);
		}
	}
	function syncPosition2(el) {
		if (syncedSecondary) {
			var number = el.item.index;
			slider.data('owl.carousel').to(number, 100, true);
		}
	}
	thumb.on("click", ".owl-item", function (e) {
		e.preventDefault();
		var number = $(this).index();
		slider.data('owl.carousel').to(number, 300, true);
	});


	$(".qtyminus").on("click", function () {
		var now = $(".qty").val();
		if ($.isNumeric(now)) {
			if (parseInt(now) - 1 > 0) { now--; }
			$(".qty").val(now);
		}
	})
	$(".qtyplus").on("click", function () {
		var now = $(".qty").val();
		if ($.isNumeric(now)) {
			$(".qty").val(parseInt(now) + 1);
		}
	});
});

function DeleteProduct(productID) {
	$.ajax({
		type: "DELETE",
		url: "https://localhost:44325/api/CartProduct/" + productID,
		dataType: "json",
		contentType: "application/json; charset=utf-8",
		success: function (response) {
			$('#productRow_' + productID).remove();
			Update(response);
		},
		failure: function () { alert("Failure"); },
		error: function () { alert("Error"); }
	});
}
function ProductInc(productID) {
	$.ajax({
		type: "GET",
		url: "https://localhost:44325/api/CartProduct/" + productID,
		dataType: "json",
		contentType: "application/json; charset=utf-8",
		success: function (response) {
			$('#productQty_' + productID).val(response.Quantity[productID]);
			$('#prodTotal_' + productID).html("$" + response.Quantity[productID] * response.UnitPrice[productID]);
			Update(response);
		},
		failure: function () { alert("Failure"); },
		error: function () { alert("Error"); }
	});
}
function ProductDec(productID) {
	$.ajax({
		type: "POST",
		url: "https://localhost:44325/api/CartProduct/",
		dataType: "json",
		data: JSON.stringify(productID),
		contentType: "application/json; charset=utf-8",
		success: function (response) {
			if (response.Quantity[productID] !== undefined) {
				$('#productQty_' + productID).val(response.Quantity[productID]);
				$('#prodTotal_' + productID).html("$" + response.Quantity[productID] * response.UnitPrice[productID]);
			} else {
				$('#productRow_' + productID).remove();
			}

			Update(response);
		},
		failure: function () { alert("Failure"); },
		error: function () { alert("Error"); }
	});
}

function ProductDirect(productID) {
	var quantity = $('#productQty_' + productID).val();
	if (quantity > 0) {
		$.ajax({
			type: "PUT",
			url: "https://localhost:44325/api/CartProduct/" + productID,
			dataType: "json",
			data: JSON.stringify(quantity),
			contentType: "application/json; charset=utf-8",
			success: function (response) {
				if (response.Quantity[productID] !== undefined) {
					$('#productQty_' + productID).val(response.Quantity[productID]);
					$('#prodTotal_' + productID).html("$" + response.Quantity[productID] * response.UnitPrice[productID]);
				} else {
					$('#productRow_' + productID).remove();
				}

				Update(response);
			},
			failure: function () { alert("Failure"); },
			error: function () { alert("Error"); }
		});
	}
}

function Update(response) {
	$('#cartCounter').html(response.CartCount);
	$('#totalPrice').html("$" + response.SubTotal);
}