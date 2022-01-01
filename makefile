publish: clean
	dotnet publish -c Release -p:PublishSingleFile=true -r linux-x64 --self-contained false

clean:
	rm -rf obj bin
