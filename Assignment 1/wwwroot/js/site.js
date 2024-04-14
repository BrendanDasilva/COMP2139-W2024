// Flight Search Results
$(document).ready(function () {
  $('#searchForm').submit(function (event) {
    event.preventDefault();
    var form = $(this);
    var url = form.attr('action');

    $.ajax({
      type: "GET",
      url: url,
      data: form.serialize(),
      beforeSend: function () {
        $('#loading').show();
      },
      complete: function () {
        $('#loading').hide();
      },
      success: function (data) {
        $('#searchResults').html(data);
      },
      error: function () {
        $('#searchResults').html('<div class="alert alert-danger">Failed to fetch results. Please try again.</div>');
      }
    });
  });
});


// Car Search Results
$(document).ready(function () {
  $('#carSearchForm').submit(function (event) {
    event.preventDefault();
    var form = $(this);
    var url = form.attr('action');

    $.ajax({
      type: "GET",
      url: url,
      data: form.serialize(),
      beforeSend: function () {
        $('#carLoading').show();
      },
      complete: function () {
        $('#carLoading').hide();
      },
      success: function (data) {
        $('#carSearchResults').html(data);
      },
      error: function () {
        $('#carSearchResults').html('<div class="alert alert-danger">Failed to fetch results. Please try again.</div>');
      }
    });
  });
});

// Hotel Searching
$(document).ready(function () {
  $('#hotelSearchForm').submit(function (event) {
    event.preventDefault();
    var form = $(this);
    var url = form.attr('action');

    $.ajax({
      type: "GET",
      url: url,
      data: form.serialize(),
      beforeSend: function () {
        $('#hotelLoading').show();
      },
      complete: function () {
        $('#hotelLoading').hide();
      },
      success: function (data) {
        $('#hotelSearchResults').html(data);
      },
      error: function () {
        $('#hotelSearchResults').html('<div class="alert alert-danger">Failed to fetch results. Please try again.</div>');
      }
    });
  });
});
