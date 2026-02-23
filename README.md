# 📋 TaskApp API - Documentação de Endpoints

Esta documentação descreve as rotas da API para o sistema de gerenciamento de tarefas desenvolvido em .NET 9. A arquitetura segue o padrão **RESTful**, utilizando **JSON** para transferência de dados.

## 🚀 Base URL
`http://localhost:5000/api` (Verifique sua porta no `launchSettings.json`)

---

## 1. Usuários (`/users`)
*Rotas para gestão de membros da equipe (utilizadas enquanto o sistema não possui JWT).*

| Método | Endpoint | Descrição |
| :--- | :--- | :--- |
| **GET** | `/users` | Lista todos os usuários cadastrados e seus IDs. |
| **POST** | `/users` | Cria um novo usuário (Ex: Membros da equipe). |

---

## 2. Projetos (`/projects`)
*Gestão de projetos e colaboração entre usuários.*

| Método | Endpoint | Descrição |
| :--- | :--- | :--- |
| **GET** | `/projects` | Lista todos os projetos no sistema. |
| **POST** | `/projects` | Cria um novo projeto. |
| **GET** | `/projects/user/{userId}` | Retorna todos os projetos associados a um usuário específico. |
| **POST** | `/projects/{projectId}/add-user/{userId}` | Vincula um usuário a um projeto (Muitos-para-Muitos). |

---

## 3. Tarefas (`/tasks`)
*Operações de rotina e controle de fluxo das tarefas.*

| Método | Endpoint | Descrição |
| :--- | :--- | :--- |
| **GET** | `/projects/{projectId}/tasks` | Lista todas as tarefas pertencentes a um projeto específico. |
| **POST** | `/tasks` | Cria uma nova tarefa vinculada a um `ProjectId`. |
| **PATCH** | `/tasks/{id}/status` | Altera o status (`0=Open`, `1=Ongoing`, `2=Conclued`). |
| **PATCH** | `/tasks/{id}/assign` | Atribui ou troca o usuário ativo (`ActiveUserId`) de uma tarefa. |

---

## 🛠️ Modelos de Dados (Exemplos de Payload)

### Criar Projeto (`POST /projects`)
```json
{
  "name": "Nome do Projeto"
}
```

### Criar Projeto (`POST /projects`)
```json
{
  "description": "Descrição da tarefa",
  "projectId": 1,
  "activeUserId": 1
}
```

### Atualizar Status (`PATCH /tasks/{id}/status`)
```json
{
  "status": 2
}
```
