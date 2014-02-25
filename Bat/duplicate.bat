rem duploをAsset/Script以下で実行するためのバッチファイル
@echo off
cd /d %~dp0..\Assets\Script
dir /s /b /a-d *.cs > files.txt
duplo files.txt result.txt
type result.txt
del files.txt
del result.txt
cd /d %~dp0
