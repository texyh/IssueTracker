var app = app || {};

app.issue = app.issue || {};

(function (vm) {
    'use strict';

    vm.init = function () {
        $('#raised-issues').click(handleIssue);
        $('#closed-issues').click(handleIssue);
        $('#my-issues').click(handleIssue);
    };

    function handleIssue(e) {
        e.preventDefault();
        var $this = $(this);
        var $ul = $this.parents('ul');
        $ul.find('li.active').removeClass('active');
        $this.addClass('active');
        var url = e.target.href;
        $('.issue-table').load(url);
    }

})(app.issue)