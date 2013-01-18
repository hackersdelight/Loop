function SetLoader() 
{
	document.getElementById("submit").style.display = 'none';
	$('.loader').show();
	return true;
}

function SetLoaderForForm(form) 
{
	if ($('#' + form).valid()) {
			document.getElementById("submit").style.display = 'none';
			$('.loader').show();
			return true;
	}
}

function SetOverlay(cls) 
{
	var myTable = $('.' + cls), targetDiv = myTable.parent('div'),
					tW = myTable.width(), tH = myTable.height(), rH = tH / 2;
	$('<div>Loading...</div>').addClass('account-overlay').css({ 'width': tW, 'height': rH, 'padding-top': rH }).prependTo(targetDiv);
	return true;
}