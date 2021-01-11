var currentPage = 1;
var pageSize = 10;
function pagePagination(totalData, pageSize, loadMethod) {
	var html2 = "";
	var option10 = pageSize == 10 ? 'selected="selected"' : '';
	var option20 = pageSize == 20 ? 'selected="selected"' : '';
	var option50 = pageSize == 50 ? 'selected="selected"' : '';
	html2 += '<div class="box-footer clearfix col-md-12"><div class="row"><div class="col col-md-4">Total count '
			+ totalData
			+ '  &nbsp; <select onchange="changePageSize(\''
			+ loadMethod
			+ '\')" id="changePageSize"> <option '
			+ option10
			+ ' value="10">10</option> <option '
			+ option20
			+ ' value="20">20</option><option '
            + option50
            + ' value="50">50</option></select></div>'
	html2 += '<div class="col col-md-8">'
	html2 += '<ul class="pagination pagination-sm no-margin pull-right">'

	if (totalData > pageSize) {

		var totalPage = Math.ceil(totalData / pageSize);
		var startPage = currentPage;
		if (totalPage > 5 && currentPage > 4) {
			startPage = currentPage - 2;
		}
		var isActive = currentPage == 1 ? 'disabled' : '';
		html2 += '<li><a href="javascript:void(0)" class="First ' + isActive
				+ '"  onclick="nextPage(1,0,this,\'' + loadMethod
				+ '\')" style="color: #3c8dbc">First</a></li>'
		html2 += '<li><a href="javascript:void(0)" class="Previous ' + isActive
				+ '" onclick="nextPage(-1,' + currentPage + ',this,\''
				+ loadMethod + '\')"  style="color: #39CCCC">Previous</a></li>'

		var i = 0;
		for (startPage; startPage <= totalPage; startPage++) {
			if (i >= 5) {
				break;
			}
			isActive = currentPage == startPage ? 'disabled' : '';
			html2 += '<li><a href="javascript:void(0)"  class="' + isActive
					+ '" onclick="nextPage(' + startPage + ',0,this,\''
					+ loadMethod + '\')">' + startPage + '</a></li>'
			i++;
		}
		isActive = currentPage == totalPage ? 'disabled' : '';
		html2 += '<li><a href="javascript:void(0)"  class="Next ' + isActive
				+ '" onclick="nextPage(1,' + currentPage + ',this,\''
				+ loadMethod + '\')"  style="color: #00a65a"> Next</a></li>'
		html2 += '<li><a href="javascript:void(0)" class="Last ' + isActive
				+ '" onclick="nextPage(' + totalPage + ',0,this,\''
				+ loadMethod + '\')"  style="color: #001F3F">Last</a></li>'

	}
	html2 += '</ul>'
	html2 += '</div></div></div><br/>';

	$("#aaaaa").html(html2)
}
function nextPage(val, curPage, sender, loadData) {
	if (!$(sender).hasClass("disabled")) {
		currentPage = (curPage + val);
		currentPage = currentPage < 1 ? 1 : currentPage;
		var fn = window[loadData];
		if (typeof fn === "function")
			fn();
	}
}
function changePageSize(loadData) {
	pageSize = $("#changePageSize").val();
	currentPage=1;
	var fn = window[loadData];
	if (typeof fn === "function")
		fn();
}