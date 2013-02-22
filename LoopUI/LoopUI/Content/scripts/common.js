function SetLoader() {
	document.getElementById("submit").style.display = 'none';
	$('.loader').show();
	return true;
}

function SetLoaderForForm(form) {
	if ($('#' + form).valid()) {
		document.getElementById("submit").style.display = 'none';
		$('.loader').show();
		return true;
	}
}

function SetOverlay(cls) {
	var myTable = $('.' + cls), targetDiv = myTable.parent('div'),
					tW = myTable.width(), tH = myTable.height(), rH = tH / 2;
	$('<div>Loading...</div>').addClass('account-overlay').css({ 'width': tW, 'height': rH, 'padding-top': rH }).prependTo(targetDiv);
	return true;
}
function AddReturnOption(grid, iCol) {
	AddGridCustomButton(grid, iCol, "Return", "ui-icon-arrowthickstop-1-w", "http://localhost:5174/Admin/Task/ReturnTask");
}

function AddPromoteOption(grid, iCol) {
	AddGridCustomButton(grid, iCol, "Promote", "ui-icon-arrowthickstop-1-e", "http://localhost:5174/Admin/Task/PromoteTask");
}

function AddPauseOption(grid, iCol) {
	AddGridCustomButton(grid, iCol, "Pause", "ui-icon-pause", "http://localhost:5174/Admin/Task/PauseTask");
}

function AddStartOption(grid, iCol) {
	AddGridCustomButton(grid, iCol, "Start", "ui-icon-play", "http://localhost:5174/Admin/Task/StartTask");
}

function AddGridCustomButton(grid, iCol, btnTitle, btnImage, operationUrl) {
	grid.children("tbody")
				.children("tr.jqgrow")
				.children("td:nth-child(" + (iCol + 1) + ")")
				.each(function () {
					$("<div>",
								{
									title: btnTitle,
									mouseover: function () {
										$(this).addClass('ui-state-hover');
									},
									mouseout: function () {
										$(this).removeClass('ui-state-hover');
									},
									click: function (e) {
										var id = $(e.target).closest("tr.jqgrow").attr("id");
										//var celValue = grid.jqGrid('getCell', selRowId, 'columnName');
										var gridData = grid.jqGrid('getRowData', id);
										gridData.id = id;
										var postData = JSON.stringify(gridData);
										SendRequest(postData, operationUrl);
									}
								}
							).css({ "margin-left": "5px", float: "left" })
								.addClass("ui-pg-div ui-inline-custom")
								.append('<span class="ui-icon ' + btnImage + '"></span>')
								.appendTo($(this).children("div"));
				});
}

function getColumnIndexByName(grid, columnName) {
	var cm = grid.jqGrid('getGridParam', 'colModel'), i = 0, l = cm.length;
	for (; i < l; i += 1) {
		if (cm[i].name === columnName) {
			return i; // return the index
		}
	}
	return -1;
}

function SendRequest(postData, url) {
	var xmlhttp = new XMLHttpRequest();
	xmlhttp.open('POST', url, 'Sync', null, null);
	xmlhttp.setRequestHeader("Content-Type", "application/json; charset=utf-8");
	xmlhttp.setRequestHeader("Content-Length", postData.length);
	xmlhttp.send(postData);
}