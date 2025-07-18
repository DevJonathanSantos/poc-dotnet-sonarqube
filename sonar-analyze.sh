#!/bin/bash

# ===============================
# Script de análise com SonarQube
# Projeto: PocSonar (.NET 8)
# ===============================

# Configurações
SONAR_TOKEN="squ_982786a4a47f06c380fd8111e7ec981a72ba48de"
SONAR_HOST="http://localhost:9000"
PROJECT_KEY="PocSonar"
SONAR_SCANNER="$HOME/.dotnet/tools/dotnet-sonarscanner"

echo "🚀 Iniciando análise com SonarQube..."

# Inicia a análise
$SONAR_SCANNER begin \
  /k:"$PROJECT_KEY" \
  /d:sonar.login="$SONAR_TOKEN" \
  /d:sonar.host.url="$SONAR_HOST" \
  /d:sonar.cs.opencover.reportsPaths="**/coverage.opencover.xml"

# Build do projeto
echo "🔧 Compilando o projeto..."
dotnet build

# Testes com cobertura
echo "🧪 Executando testes..."
dotnet test --no-build

# Finaliza a análise
echo "📤 Finalizando análise..."
$SONAR_SCANNER end /d:sonar.login="$SONAR_TOKEN"

echo "✅ Análise concluída! Acesse: $SONAR_HOST/dashboard?id=$PROJECT_KEY"
