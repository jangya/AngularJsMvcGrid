(function(){
    var suggestReportApp = angular.module('suggestReportApp', []);

suggestReportApp.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
}]);

suggestReportApp.controller('SuggestReportController', function ($scope, $http) {

        //  We'll load our list of Customers from our JSON Web Service into this variable
        $scope.listOfIssues = null;
		$scope.editorEnabled = false;
        //  When the user selects a "Customer" from our MasterView list, we'll set this variable.
        $scope.selectedIssue = null;
		$scope.selectedIssueId = null;

        $http.get('/SuggestReport/getAllIssues')

            .success(function (data) {
                $scope.listOfIssues = data;

                   //  If we managed to load more than one Customer record, then select the 
                   //  first record by default.
                   $scope.selectedIssueId = $scope.listOfIssues[0].ID;
				   $scope.selectedIssue = $scope.listOfIssues[0];
                   //  Load the list of Orders, and their Products, that this Customer has ever made.
                   $scope.loadComments();
            });
		$scope.loadComments = function () {
			//  The user has selected a Customer from our Drop Down List.  Let's load this Customer's records.
		    $http.get('/SuggestReport/getComments/' + $scope.selectedIssueId)
				.success(function (data) {
					$scope.listOfComments = data;
				})
				.error(function (data, status, headers, config) {
					$scope.errorMessage = "Couldn't load the list of Orders, error # " + status;
				});
		};
		$scope.selectIssue = function (val) {
			$scope.selectedIssueId = val.ID;
			$scope.selectedIssue = val;
			$scope.loadComments();
			
		};
		$scope.editIssue = function (val) {

		    $http.post('/SuggestReport/updateIssue/', $scope.selectedIssue)
				.success(function (data) {
				    $scope.listOfIssues = data;
				    $('#exampleModal').modal('hide');
				})
				.error(function (data, status, headers, config) {
				    $scope.errorMessage = "Couldn't update the record, error # " + status;
				});
			//console.log(val);
		};
	});
suggestReportApp.directive('modalTemplate', function () {
		return {
			restrict: 'E',
			templateUrl: 'modal-template.html'
		}
	});
suggestReportApp.filter('PriorityFilter', function () {
		return function (val) {
			//  Count how many items are in this order
			var priority = {
				0:'critical',
				1:'high',
				2:'medium',
				3:'low'
			};
			return priority[val];
			
		}
	});
suggestReportApp.filter('statusFilter', function () {
		return function (val) {
			//  Count how many items are in this order
			var status = {
				0:'open',
				1:'Not an issue',
				2:'wip',
				3:'Paused',
				4:'Closed',
				5:'Hidden'
			};
			return status[val];
			
		}
});
suggestReportApp.filter('jsonDate', function ($filter) {
    return function (input, format) {
        return $filter('date')(parseInt(input.substr(6)), format);
    };

});
})();


