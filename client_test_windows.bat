cd BlabberApp.ClientTest
dotnet add package coverlet.msbuild
dotnet test /p:CollectCoverage=true /p:CoverLetOutput=TestResults /p:CoverletOutputFormat=lcov
/tools/reportgenerator -reports:./TestResults.info -targetdir:./TestResults/