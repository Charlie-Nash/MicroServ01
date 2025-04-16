# MicroServ01

Microservicio construido con **ASP.NET Core** que expone una API para realizar consultas a una base de datos MySQL. Desarrollado bajo principios de arquitectura limpia, con soporte para contenedores Docker.

## 🚀 Características

- API RESTful construida con ASP.NET Core.
- Integración con MySQL.
- Arquitectura por capas (Domain, Application, Infrastructure, API).
- Preparado para despliegue en Docker.
- Endpoint principal para consultas de datos según criterios.

---

## 🛠️ Tecnologías utilizadas

- .NET Core
- MySQL
- Docker & Docker Compose
- Clean Architecture (Separación de responsabilidades)

---

## 📦 Docker Compose

```yaml
services:
  api:
    build:
      context: .
      dockerfile: MicroServ01.Api/Dockerfile
    ports:
      - "5001:8080"
    environment:
      - ConnectionStrings__dbMicro01=Server=127.0.0.1;Port=3306;Database=${MYSQL_DATABASE};User=root;Password=${MYSQL_ROOT_PASSWORD};
```

---

## 📬 Endpoint disponible

### POST `/api/v1/micro01/listado`

Consulta listado de estudiantes filtrando por sexo y carrera.

#### 🔹 Request JSON
```json
{
  "Sexo": "FEMENINO",
  "Carrera": "CONTA"
}
```

#### 🔹 Response JSON
```json
[
  {
    "Id": 1,
    "Semestre": "2023-02",
    "Sexo": "FEMENINO",
    "FecNac": "20021207",
    "Ubigeo": "150101",
    "Carrera": "CONTA",
    "Ciclo": "9",
    "FecIngreso": "2019-1",
    "Modalidad": "Presencial",
    "CreditosAcum": 84,
    "Mensaje": ""
  }
]
```

---

## ▶️ Cómo ejecutar

1. Clonar este repositorio:
   ```bash
   git clone https://github.com/Charlie-Nash/MicroServ01.git
   cd MicroServ01
   ```

2. Crear un archivo `.env` con las siguientes variables:
   ```env
   MYSQL_DATABASE=db_baja
   MYSQL_ROOT_PASSWORD=tu_password
   ```

3. Ejecutar con Docker Compose:
   ```bash
   sudo docker-compose up --build -d
   o
   sudo docker compose up --build -d
   ```

4. Acceder a la API en:  
   [http://localhost:5001/api/v1/micro01/listado](http://localhost:5001/api/v1/micro01/listado)

---

## 👤 Autor

Desarrollado por **Charlie Nash**

---

## 📄 Licencia

Este proyecto se puede usar libremente para fines educativos o personales.