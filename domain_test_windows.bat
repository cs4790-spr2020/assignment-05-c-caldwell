cd BlabberApp.DomainTest
dotnet add package coverlet.msbuild
dotnet test /p:CollectCoverage=true /p:CoverLetOutput=TestResults /p:CoverletOutputFormat=lcov
cd ../tools/reportgenerator -reports:./TestResults.info -targetdir:./TestResults/
