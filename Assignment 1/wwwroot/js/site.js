// Search Functions
$(document).ready(function () {
  // Function to handle search form submission
  function handleSearchForm(formId, loadingId, resultsId) {
    $(formId).submit(function (event) {
      event.preventDefault();
      var form = $(this);
      var url = form.attr('action');

      $.ajax({
        type: "GET",
        url: url,
        data: form.serialize(),
        beforeSend: function () {
          $(loadingId).show();
        },
        complete: function () {
          $(loadingId).hide();
        },
        success: function (data) {
          $(resultsId).html(data);
        },
        error: function () {
          $(resultsId).html('<div class="alert alert-danger">Failed to fetch results. Please try again.</div>');
        }
      });
    });
  }

  // Flight Search
  handleSearchForm('#searchForm', '#loading', '#searchResults');

  // Car Search
  handleSearchForm('#carSearchForm', '#carLoading', '#carSearchResults');

  // Hotel Search
  handleSearchForm('#hotelSearchForm', '#hotelLoading', '#hotelSearchResults');
});

