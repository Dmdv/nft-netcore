OS = $(shell uname | tr A-Z a-z)
export PATH := $(abspath bin/):${PATH}
VERBOSE = 1

.PHONY: help build
.DEFAULT_GOAL := help
help:
	@grep -h -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}'

docker: ## builds docker image
	@docker build --file ./Dockerfile -t nft:latest  ../.
	
build: ## run server
	@dotnet build "nft-netcore.csproj" -c Release -o ./build
	
run: build ## run server
	@dotnet ./build/nft-netcore.dll
	