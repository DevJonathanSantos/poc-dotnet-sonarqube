#!/bin/bash

# ===============================
# Script de análise com SonarQube
# Projeto: PocSonar (.NET 8)
# ===============================

# Configurações
SONAR_TOKEN="squ_a1cccac9d628f3b50fa289434c70803310a061f9"
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
