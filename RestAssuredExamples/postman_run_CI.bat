newman run "postman_CI_Tests.postman_collection.json" -e "postman_Test Environment 1.postman_environment.json" -r cli,junit --reporter-junit-export "TestResults/postman_junit_results.xml" 
pause
