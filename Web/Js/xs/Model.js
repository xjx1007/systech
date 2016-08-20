
function set_return_Customer(Customer_id, Customer_name, LinkCode) {
        alert("1")
        window.opener.document.EditView.Tbx_CustomerName.value = Customer_name;
        window.opener.document.EditView.Tbx_CustomerValue.value = Customer_id;
		if(window.opener.document.EditView.Tbx_Code != undefined) {
			window.opener.document.EditView.Tbx_Code.value = LinkCode;
		}

}
