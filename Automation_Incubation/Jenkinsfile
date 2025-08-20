pipeline {
    agent any

    environment {
        SOLUTION_NAME = "Automation_Incubation.dll"
        TEST_DLL = "D:\Automation_Incubation_Repo\Automation_Incubation\bin\Debug\net8.0\Automation_Incubation.dll"
        GIT_REPO = "https://github.com/Ajay655202/Automation_Incubation.git"
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: "${GIT_REPO}"
            }
        }

        stage('Restore Packages') {
            steps {
                bat "nuget restore ${SOLUTION_NAME}"
            }
        }

        stage('Build Solution') {
            steps {
                bat "\"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe\" ${SOLUTION_NAME} /p:Configuration=Debug"
            }
        }

        stage('Run Regression Tests') {
            steps {
                bat "\"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\Common7\\IDE\\CommonExtensions\\Microsoft\\TestWindow\\vstest.console.exe\" ${TEST_DLL} --TestCaseFilter:TestCategory=Regression /logger:trx"
            }
        }

        stage('Publish Results') {
            steps {
                mstest testResultsFile:"**/*.trx"
            }
        }
    }
}
