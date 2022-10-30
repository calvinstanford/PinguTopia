# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2022-08-04
### Changed
  * Dependency version bump for core and auth package

## [1.0.1] - 2022-05-25
### Changed
  * The IChannel methods will now throw an ObjectDisposedException if the object was disposed.
  * Fix some cases of unexpected disconnection that didn't trigger a reconnect.

## [1.0.0-preview.14] - 2022-03-09
### Changed
  * IChannel will unsubscribe on Dispose but not if triggered by the finalizer.

## [1.0.0-preview.5] - 2022-02-26
  * Updated changelog.

## [1.0.0-preview.4] - 2022-02-25
  * Wire service URLs updated to reflect the new DNS domain.

## [1.0.0-preview] - 2022-02-21
### This is the first supported release of the *Wire* SDK.
  * fix package being stripped away from iOS build.
  * fix bug where Unity Editor would hang on domain reload.

## [0.0.1-preview] - 2021-09-29
### This is the first release of the *Wire* SDK.
- Working prototype of the Wire SDK package.
