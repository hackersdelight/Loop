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
	grid.children("tbody")
				.children("tr.jqgrow")
				.children("td:nth-child(" + (iCol + 1) + ")")
				.each(function () {
					$("<div>",
								{
									//style: "margin-left: 5px; float:left",
									//class: "ui-pg-div ui-inline-custom",
									title: "Start",
									mouseover: function () {
										$(this).addClass('ui-state-hover');
									},
									mouseout: function () {
										$(this).removeClass('ui-state-hover');
									},
									click: function (e) {
										alert("'Custom' button is clicked in the rowis=" +
															$(e.target).closest("tr.jqgrow").attr("id") + " !");
									}
								}
							).css({ "margin-left": "5px", float: "left" })
								.addClass("ui-pg-div ui-inline-custom")
								.append('<span class="ui-icon ui-icon-arrowthickstop-1-w"></span>')
								.appendTo($(this).children("div"));
				});
}

function AddPromoteOption(grid, iCol) {
	grid.children("tbody")
			.children("tr.jqgrow")
			.children("td:nth-child(" + (iCol + 1) + ")")
			.each(function () {
				$("<div>",
							{
								//style: "margin-left: 5px; float:left",
								//class: "ui-pg-div ui-inline-custom",
								title: "Start",
								mouseover: function () {
									$(this).addClass('ui-state-hover');
								},
								mouseout: function () {
									$(this).removeClass('ui-state-hover');
								},
								click: function (e) {
									alert("'Custom' button is clicked in the rowis=" +
														$(e.target).closest("tr.jqgrow").attr("id") + " !");
								}
							}
						).css({ "margin-left": "5px", float: "left" })
							.addClass("ui-pg-div ui-inline-custom")
							.append('<span class="ui-icon ui-icon-arrowthickstop-1-e"></span>')
							.appendTo($(this).children("div"));
			});
}

function AddPauseOption(grid, iCol) {
	grid.children("tbody")
				.children("tr.jqgrow")
				.children("td:nth-child(" + (iCol + 1) + ")")
				.each(function () {
					$("<div>",
								{
									//style: "margin-left: 5px; float:left",
									//class: "ui-pg-div ui-inline-custom",
									title: "Start",
									mouseover: function () {
										$(this).addClass('ui-state-hover');
									},
									mouseout: function () {
										$(this).removeClass('ui-state-hover');
									},
									click: function (e) {
										alert("'Custom' button is clicked in the rowis=" +
															$(e.target).closest("tr.jqgrow").attr("id") + " !");
									}
								}
							).css({ "margin-left": "5px", float: "left" })
								.addClass("ui-pg-div ui-inline-custom")
								.append('<span class="ui-icon ui-icon-pause"></span>')
								.appendTo($(this).children("div"));
				});
}

function AddStartOption(grid, iCol) {
	grid.children("tbody")
				.children("tr.jqgrow")
				.children("td:nth-child(" + (iCol + 1) + ")")
				.each(function () {
					$("<div>",
								{
									//style: "margin-left: 5px; float:left",
									//class: "ui-pg-div ui-inline-custom",
									title: "Start",
									mouseover: function () {
										$(this).addClass('ui-state-hover');
									},
									mouseout: function () {
										$(this).removeClass('ui-state-hover');
									},
									click: function (e) {
										alert("'Custom' button is clicked in the rowis=" +
															$(e.target).closest("tr.jqgrow").attr("id") + " !");
									}
								}
							).css({ "margin-left": "5px", float: "left" })
								.addClass("ui-pg-div ui-inline-custom")
								.append('<span class="ui-icon ui-icon-play"></span>')
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