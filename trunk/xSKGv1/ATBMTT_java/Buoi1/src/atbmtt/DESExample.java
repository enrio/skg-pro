package atbmtt;

import javax.crypto.*;

public class DESExample {
	public static void main(String[] args) {
		try {
			// MÃ HOÁ
			// 1. Tạo cipher
			Cipher cipher = Cipher.getInstance("DES");
			//Cipher cipher = Cipher.getInstance("DES/ECB/NoPadding"); // lỗi
			//Cipher cipher = Cipher.getInstance("DES/ECB/PKCS5Padding");
			
			// 2. Tạo khóa ngẫu nhiên
			KeyGenerator gen = KeyGenerator.getInstance("DES");
			SecretKey key = gen.generateKey();

			// 3. Khởi động bộ mã hóa
			cipher.init(Cipher.ENCRYPT_MODE, key);

			// 4. Mã hóa dữ liệu
			String input = "Hello Mr. Zng Tfy!";
			byte[] cipherText = cipher.doFinal(input.getBytes());

			// 5. In kết quả ra màn hình
			for (int i = 0; i < cipherText.length; i++)
				System.out.print(cipherText[i] + " ");
			System.out.println();

			// GIẢI MÃ
			// Khởi động giải mã và giải mã
			cipher.init(Cipher.DECRYPT_MODE, key);
			byte[] kq = cipher.doFinal(cipherText);

			// In kết quả ra màn hình
			for (int i = 0; i < kq.length; i++)
				System.out.print((char) kq[i] + " ");
			System.out.println();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
