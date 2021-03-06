dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools
cd BlabberApp.ServicesTest
dotnet add package coverlet.msbuild
dotnet test /p:CollectCoverage=true /p:CoverLetOutput=TestResults /p:CoverletOutputFormat=lcov
../tools/reportgenerator -reports:./TestResults.info -targetdir:./TestResults/
