$(document).ready(function () {
	Load_All_Products();
});

function Load_All_Products() {
	$.ajax({
		url: 'http://localhost:5035/API/Product',
		method: 'GET',
		contentType: 'application/json;charset=utf-8',
		dataType: 'json',
		success: function (result) { CreateProducts(result); },
		error: function (error) { console.log(error); }
	});
}

function CreateProducts(products) {
	//console.log(products);
	$.each(products, function (i, product) {
		$('#ProductsDiv').append(ProductFactory(product));
	})
}

function ProductFactory(product) {
	var result =
		`<div class="col-lg-4 col-md-6 mb-4">
			<div class="card h-100">
				<a href="#"><img class="card-img-top" src="https://placehold.co/700x400" alt=""></a>
				<div class="card-body">
					<h4 class="card-title">
						<a href="#">${product.productName}</a>
					</h4>
					<h5>$${product.unitPrice}</h5>
					<p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>
				</div>
				<div class="card-footer">
					<small class="text-muted">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
				</div>
			</div>
		</div>`;
	return result;
}