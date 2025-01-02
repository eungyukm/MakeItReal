from django.db import models
from django.utils.timezone import now


class User(models.Model):
    username = models.CharField(max_length=150)
    email = models.EmailField(unique=True)
    password = models.CharField(max_length=128)
    date_joined = models.DateTimeField(default=now)
    is_active = models.BooleanField()

    def __init__(self, username, email, password, is_active):
        super().__init__()
        self.username = username
        self.email = email
        self.password = password
        self.is_active = is_active

    def save(self, *args, **kwargs):
        self.email = self.email.lower()
        if not self.date_joined:
            self.date_joined = now()
        super().save(*args, **kwargs)
