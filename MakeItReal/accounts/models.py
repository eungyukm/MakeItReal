from django.db import models
from django.utils.timezone import now


class User(models.Model):
    username = models.CharField(max_length=150)
    email = models.EmailField(unique=True)
    password = models.CharField(max_length=128)
    date_joined = models.DateTimeField(default=now)
    is_active = models.BooleanField()

    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.username = kwargs.get('username', '')
        self.email = kwargs.get('email', '')
        self.password = kwargs.get('password', '')
        self.is_active = kwargs.get('is_active', True)

    def save(self, *args, **kwargs):
        self.email = self.email.lower()
        if not self.date_joined:
            self.date_joined = now()
        super().save(*args, **kwargs)
