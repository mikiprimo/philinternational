//function ChangeStatusCheckBox(obj) {
//    
//    objey = "lblStatus_" + obj;
//    alert(objey);
//    $(objey).html('<a>masicatti</a>');
//    $.ajax({
//        type: "POST",
//        url: "../Management/news.aspx/ChangeStatus",
//        data: "{obj}",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (response) {
//            objey = "lblStatus_" + obj;
//            $(objey).value = "kjsdjsl";
//        }
//    });

//}


//   function sstchur_SmartScroller_GetCoords()
//   {
//      var scrollX, scrollY;
//      
//      if (document.all)
//      {
//         if (!document.documentElement.scrollLeft)
//            scrollX = document.body.scrollLeft;
//         else
//            scrollX = document.documentElement.scrollLeft;
//               
//         if (!document.documentElement.scrollTop)
//            scrollY = document.body.scrollTop;
//         else
//            scrollY = document.documentElement.scrollTop;
//      }   
//      else
//      {
//         scrollX = window.pageXOffset;
//         scrollY = window.pageYOffset;
//      }
//   
//      document.forms[formID].xCoordHolder.value = scrollX;
//      document.forms[formID].yCoordHolder.value = scrollY;
//   }
//   
//   function sstchur_SmartScroller_Scroll()
//   {
//      var x = document.forms[formID].xCoordHolder.value;
//      var y = document.formsformID].yCoordHolder.value;
//      window.scrollTo(x, y);
//   }
//   
//   window.onload = sstchur_SmartScroller_Scroll;
//   window.onscroll = sstchur_SmartScroller_GetCoords;
//   window.onkeypress = sstchur_SmartScroller_GetCoords;
//   window.onclick = sstchur_SmartScroller_GetCoords;