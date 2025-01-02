from django.db import models
from django.utils.timezone import now


class User(models.Model):
    username = models.CharField(max_length=150)
    email = models.EmailField(unique=True)
    password = models.CharField(max_length=128)
    date_joined = models.DateTimeField(default=now)
    is_active = models.BooleanField(default=True)

    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)

    def save(self, *args, **kwargs):
        # 이메일을 소문자로 저장
        self.email = self.email.lower()
        if not self.date_joined:
            self.date_joined = now()
        super().save(*args, **kwargs)