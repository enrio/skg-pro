package atbmtt;

import java.io.*;
import java.net.*;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.interfaces.RSAPrivateKey;
import java.security.interfaces.RSAPublicKey;

import javax.crypto.*;
import javax.crypto.spec.*;

public class Client {
	public static void main(String[] args) {
		try {
			// Sinh ngẫu nhiên 1 cặp khoá
			KeyPairGenerator gen = KeyPairGenerator.getInstance("RSA");
			KeyPair key = gen.generateKeyPair();

			// Tạo khoá công khai kp, khoá bí mật ks
			RSAPublicKey kp_Client = (RSAPublicKey) key.getPublic();
			RSAPrivateKey ks_Client = (RSAPrivateKey) key.getPrivate();
			
			// 1. Kết nối đến server trên cổng 3333
			Socket s = new Socket("127.0.0.1", 3333);

			// 2. Lấy InputStream và OutputStream từ Socket s
			InputStream is = s.getInputStream();
			OutputStream os = s.getOutputStream();
			
			// Gởi khoá kp cho Server
			os.write(kp_Client.getEncoded());

			// 3. Đọc dữ liệu từ Socket
			byte[] msg = new byte[1000];
			int n = is.read(msg);
			System.out.println("Nhận dữ liệu từ server:");

			for (int i = 0; i < n; i++)
				System.out.print((char) msg[i]);
			System.out.println();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}