# gitからpyenv-winをクローンして、環境変数を設定するスクリプト

# エンコーディングを明示的に指定する
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

Write-Output "pyenv-win をインストールします。`r`n"

# pyenv-winをgitからクローン
git clone https://github.com/pyenv-win/pyenv-win.git "$env:USERPROFILE\.pyenv"

Write-Output "==="

# 環境変数を設定
$pyenv = "$env:USERPROFILE\.pyenv\pyenv-win"
$pyenvRoot = "$env:USERPROFILE\.pyenv\pyenv-win"
$pyenvHome = "$env:USERPROFILE\.pyenv\pyenv-win"

# 環境変数を設定

try {
    [Environment]::SetEnvironmentVariable("PYENV", $pyenv, [EnvironmentVariableTarget]::User)
    Write-Output "環境変数 PYENV が正常に設定されました。"
} catch {
    Write-Output "環境変数 PYENV の設定に失敗しました。エラー: $_"
}

try {
    [Environment]::SetEnvironmentVariable("PYENV_ROOT", $pyenvRoot, [EnvironmentVariableTarget]::User)
    Write-Output "環境変数 PYENV_ROOT が正常に設定されました。"
} catch {
    Write-Output "環境変数 PYENV_ROOT の設定に失敗しました。エラー: $_"
}

try {
    [Environment]::SetEnvironmentVariable("PYENV_HOME", $pyenvHome, [EnvironmentVariableTarget]::User)
    Write-Output "環境変数 PYENV_HOME が正常に設定されました。"
} catch {
    Write-Output "環境変数 PYENV_HOME の設定に失敗しました。エラー: $_"
}

function Add-ToPath {
    param (
        [string]$dirPath
    )

    # 現在のユーザー環境変数のPathを取得
    $currentPath = [Environment]::GetEnvironmentVariable("Path", [EnvironmentVariableTarget]::User)

    # 新しいパスが既に現在のパスに含まれているかをチェック
    if ($currentPath -notlike "*$dirPath*") {
        # パスが含まれていない場合にのみ追加
        $newPath = "$currentPath;$dirPath"
        [Environment]::SetEnvironmentVariable("Path", $newPath, [EnvironmentVariableTarget]::User)
        Write-Output "Pathに新しいディレクトリ '$dirPath' を追加しました。"
    } else {
        Write-Output "Pathにすでにディレクトリ '$dirPath' が含まれています。"
    }
}

$pyenvShims = "$env:USERPROFILE\.pyenv\pyenv-win\shims"
$pyenvBin = "$env:USERPROFILE\.pyenv\pyenv-win\bin"

Add-ToPath($pyenvShims)
Add-ToPath($pyenvBin)

pyenv rehash

Write-Output "==="
