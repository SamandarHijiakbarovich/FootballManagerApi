# ⚽ Football Manager API

FootballManagerApi — bu ASP.NET Core Web API bo‘lib, unda jamoalar (teams), o‘yinchilar (players), o‘yinlar (matches) va gollar (goals) bilan ishlovchi RESTful API yozilgan.

## 📚 Loyiha haqida

Bu loyiha futbolga oid ma'lumotlarni boshqarish uchun CRUD funksiyalarni o‘z ichiga oladi. Har bir modul uchun (Player, Team, Match, Goal) alohida xizmatlar (services) va controllerlar yozilgan.

## 🛠 Texnologiyalar

- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- SQL Server
- Swagger (API testing uchun)
- Git & GitHub

## 🔗 Asosiy API endpointlar
### 🧍 Player
GET     /api/player              // Barcha o'yinchilar ro'yxati
GET     /api/player/{id}         // ID bo'yicha bitta o'yinchi
POST    /api/player              // Yangi o'yinchi qo'shish
PUT     /api/player/{id}         // O'yinchini tahrirlash
DELETE  /api/player/{id}         // O'yinchini o'chirish

### 🏟️ Team
GET     /api/team                // Barcha jamoalar ro'yxati
GET     /api/team/{id}           // ID bo'yicha jamoa
POST    /api/team                // Yangi jamoa yaratish
PUT     /api/team/{id}           // Jamoani yangilash
DELETE  /api/team/{id}           // Jamoani o'chirish

### ⚽ Match
GET     /api/match               // Barcha o'yinlar ro'yxati
GET     /api/match/{id}          // ID bo'yicha o'yin
POST    /api/match               // Yangi o'yin qo'shish
PUT     /api/match/{id}          // O'yinni yangilash
DELETE  /api/match/{id}          // O'yinni o'chirish

### 🎯 Goal
GET     /api/goal                // Barcha gollar ro'yxati
GET     /api/goal/{id}           // ID bo'yicha gol
POST    /api/goal                // Yangi gol qo'shish
PUT     /api/goal/{id}           // Golni tahrirlash
DELETE  /api/goal/{id}           // Golni o'chirish
