
# ⚽ Football Manager API

**FootballManagerApi** — bu ASP.NET Core Web API bo‘lib, unda jamoalar (teams), o‘yinchilar (players), o‘yinlar (matches) va gollar (goals) bilan ishlovchi RESTful API yozilgan.

## 📚 Loyiha haqida

Bu loyiha futbolga oid ma'lumotlarni boshqarish uchun CRUD funksiyalarni o‘z ichiga oladi. Har bir modul uchun (Player, Team, Match, Goal) alohida xizmatlar (services) va controllerlar yozilgan.

Loyihada foydalanuvchi autentifikatsiyasi va avtorizatsiyasi JWT (JSON Web Token) orqali amalga oshiriladi. Admin rollari orqali faqat ruxsat berilgan foydalanuvchilar muhim amallarni bajarishi mumkin.

## 🛠 Texnologiyalar

- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- SQL Server
- JWT (JSON Web Tokens)
- Swagger (API testing uchun)
- Git & GitHub

## 🔐 Autentifikatsiya va avtorizatsiya (Auth)

### 🔑 Endpoints:

#### 📝 Register (foydalanuvchi ro‘yxatdan o‘tadi)
```
POST /api/auth/register
```
**Body:**
```json
{
  "username": "johndoe",
  "password": "MySecure123",
  "fullName": "John Doe",
  "email": "john@example.com",
  "phoneNumber": "+998901234567"
}
```

#### 🔓 Login (token olish)
```
POST /api/auth/login
```
**Body:**
```json
{
  "username": "johndoe",
  "password": "MySecure123"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

#### 🛡️ Himoyalangan endpoint (Admin-only misol)
```
GET /api/auth/admin-only
Header: Authorization: Bearer <your_token_here>
```

## 🔗 Asosiy API endpointlar

### 🧍 Player
| Endpoint | Tavsif |
|---------|--------|
| GET    `/api/player`           | Barcha o'yinchilar ro'yxati |
| GET    `/api/player/{id}`      | ID bo'yicha bitta o'yinchi |
| POST   `/api/player`           | Yangi o'yinchi qo'shish |
| PUT    `/api/player/{id}`      | O'yinchini tahrirlash |
| DELETE `/api/player/{id}`      | O'yinchini o'chirish |

### 🏟️ Team
| Endpoint | Tavsif |
|---------|--------|
| GET    `/api/team`             | Barcha jamoalar ro'yxati |
| GET    `/api/team/{id}`        | ID bo'yicha jamoa |
| POST   `/api/team`             | Yangi jamoa yaratish |
| PUT    `/api/team/{id}`        | Jamoani yangilash |
| DELETE `/api/team/{id}`        | Jamoani o'chirish |

### ⚽ Match
| Endpoint | Tavsif |
|---------|--------|
| GET    `/api/match`            | Barcha o'yinlar ro'yxati |
| GET    `/api/match/{id}`       | ID bo'yicha o'yin |
| POST   `/api/match`            | Yangi o'yin qo'shish |
| PUT    `/api/match/{id}`       | O'yinni yangilash |
| DELETE `/api/match/{id}`       | O'yinni o'chirish |

### 🎯 Goal
| Endpoint | Tavsif |
|---------|--------|
| GET    `/api/goal`             | Barcha gollar ro'yxati |
| GET    `/api/goal/{id}`        | ID bo'yicha gol |
| POST   `/api/goal`             | Yangi gol qo'shish |
| PUT    `/api/goal/{id}`        | Golni tahrirlash |
| DELETE `/api/goal/{id}`        | Golni o'chirish |

## 📄 Litsenziya

Ushbu loyiha ochiq manbali va o‘rganish maqsadida yaratilgan.

---

👨‍💻 **Muallif:** Samandar Mamasoatov  
📅 **Loyiha boshlangan sana:** 03.06.2025  
📧 **Bog‘lanish:** mamasoatovsamandar5@gmail.com
