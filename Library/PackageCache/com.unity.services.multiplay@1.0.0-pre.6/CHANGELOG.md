# Changelog

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.0.0-pre.6] - 2022-08-12

* Now supports Unity Editor Version 2020.3

## [1.0.0-pre.5] - 2022-08-03

* Updating supported unity editor version

## [1.0.0-pre.4] - 2022-08-02

* Fixed documentation and README
* Updated package dependencies

## [1.0.0-pre.3] - 2022-07-22

* Improved XML Docs for readiness
* Fixed an issue where, when deserializing a JSON response, a null reference exception could be thrown.
* Renamed IServerCheckManager to IServerQueryHandler
* Marked ServerConfig with Preserve attribute to protect it from code stripping
* Renamed AllocatedUuid to AllocationId

## [1.0.0-pre.2] - 2022-06-24

* Renamed some functions:
 * ServerReadyForPlayersAsync -> ReadyServerForPlayersAsync
 * ServerUnreadyAsync -> UnreadyServerAsync
 * ConnectToServerCheckAsync -> StartServerQueryHandlerAsync
* Fixed connection to payloadproxy
* Windows builds now uses HOMEPATH instead of HOME to read server.json

## [1.0.0-pre.1] - 2022-03-28

* Initial version of the Multiplay SDK package.
